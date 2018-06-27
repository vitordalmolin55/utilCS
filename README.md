int rossoPin= 2;
int verdePin = 3;
int bluPin = 4;

int micro = A0;

void rgb(int rosso, int verde, int blu);
void setup() {
  pinMode(rossoPin, OUTPUT);
  pinMode(verdePin, OUTPUT);
  pinMode(bluPin, OUTPUT);
  pinMode(micro, INPUT);
  Serial.begin(9600);  
}
void loop() {
  int n = analogRead(micro);
  Serial.println(n);
  if(n <= 513){
    digitalWrite(bluPin, HIGH);
    digitalWrite(verdePin, LOW);
    digitalWrite(rossoPin, LOW);
  } else if( n > 513 && n < 520){
    digitalWrite(verdePin, HIGH);
    digitalWrite(rossoPin, LOW);
    digitalWrite(bluPin, LOW);
  } else if(n >= 520){
    digitalWrite(rossoPin, HIGH);
    digitalWrite(bluPin, LOW);
    digitalWrite(verdePin, LOW);
  }
  Serial.println("finalizou");
  delay(10);
}
void rgb(int rosso, int verde, int blu){
  analogWrite(rossoPin, rosso);
  analogWrite(verdePin, verde);
  analogWrite(bluPin, blu);
}
