#include <msp430.h> 

#define DIG_POT_INCREMENT_DRAIN 125
#define DIG_POT_INCREMENT_GATE 12500
#define DIG_POT_INCREMENT_GATECOUNT 25000
#define DIG_POT_RESET_GATECOUNT 10

void setupPorts();
void setupADC();
void setupTimer();
void sampleADC();

int getAverageADCValue();

int adc[100] = {0};
int avg_adc = 0;

unsigned int count;
unsigned int gateCount;

void main() {
  WDTCTL = WDTPW + WDTHOLD;
  setupPorts();
  setupTimer();
  setupADC();

  while(1) {
      sampleADC();
      avg_adc = getAverageADCValue();
  }
}

void setupADC() {
  ADC10CTL1 = CONSEQ_2 + INCH_0;
  ADC10CTL0 = ADC10SHT_2 + MSC + ADC10ON + ADC10IE;
  ADC10DTC1 = 0x64;
  ADC10AE0 |= 0x01;
}

void setupTimer() {
	BCSCTL1 = CALBC1_1MHZ;
	DCOCTL = CALDCO_1MHZ;
	TACCR0 = 0;
	TACCTL0 |= CCIE;
	TACTL = TASSEL_2 + ID_0 + MC_1;
	_enable_interrupt();
	count = 0;
	TACCR0 = 1000-1;
}

void setupPorts() {
	P1SEL &= ~BIT1;
  P1DIR |= BIT1;
  P1SEL &= ~BIT3;
  P1DIR |= BIT3;
  P1SEL &= ~BIT4;
  P1DIR |= BIT4;
  P1SEL &= ~BIT5;
  P1DIR |= BIT5;
}

void sampleADC() {
  ADC10CTL0 &= ~ENC;
  while (ADC10CTL1 & BUSY);
  ADC10SA = (int)adc;
  ADC10CTL0 |= ENC + ADC10SC;
  __bis_SR_register(CPUOFF + GIE);
}

int getAverageADCValue() {
  int i;
  int runningTotal = 0;
  for(i = 0; i < 100; i++) {
      runningTotal += adc[i];
  }
  int runningTotal /= 100
  return runningTotal;
}


#pragma vector=ADC10_VECTOR
__interrupt void ADC10_ISR(void)
{
  __bic_SR_register_on_exit(CPUOFF);
}

#pragma vector = TIMER0_A0_VECTOR
__interrupt void Timer_A_CCR0_ISR(void)
{
	count++;

	if ((count % DIG_POT_INCREMENT_DRAIN) == 0){
	    P1OUT ^= BIT5;
	}

	if ((count % DIG_POT_INCREMENT_GATE) == 0){
	    P1OUT ^= BIT3;
	}

	if ((count >= DIG_POT_INCREMENT_GATECOUNT) == 0){
	    P1OUT ^= BIT4;
	    gateCount++;
	    count = 0;
	}

	if(gateCount == 10){
	    P1OUT ^= BIT1;
	    gateCount = 0;
	}
}