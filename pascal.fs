VARIABLE NEXT-TERM-ADDR

: BACKWARDS ( addr -- addr' )
  -1 CELLS + ;

: ADD ( addr -- [addr]+[addr+1] )
  DUP @ SWAP CELL+ @ + ;

: TERM, ( n -- )
  NEXT-TERM-ADDR @ !
  CELL NEXT-TERM-ADDR +! ;

: LINE,
  NEXT-TERM-ADDR @
  1 TERM,
  BACKWARDS
  BEGIN
    BACKWARDS
    DUP ADD TERM,
    DUP @ 1 =
  UNTIL DROP
  1 TERM, ;

: LINES, ( n -- )
  0 DO LINE, LOOP ;

: SUM ( n -- n )
  DUP IF 1+ 0 SWAP 1 DO I + LOOP THEN ;

: .TERMS ( addr,n -- )
  0 DO DUP I CELLS + @ . LOOP CR DROP ;

: LINE-ADDR ( addr,n -- addr )
  SUM CELLS + ;

: .LINE ( addr,n -- )
    TUCK LINE-ADDR SWAP 1+ .TERMS ;

: .LINES ( addr,n -- ) 
  0 DO DUP I .LINE LOOP DROP ;

CREATE TRIANGLE 20 SUM CELLS ALLOT
TRIANGLE NEXT-TERM-ADDR !
1 TERM,
1 TERM, 1 TERM,
23 LINES,

CR TRIANGLE 25 .LINES
BYE


