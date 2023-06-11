VARIABLE NEXT-ADDR

: BACKWARDS ( addr -- addr' )
  -1 CELLS + ;

: ADD ( addr -- [addr]+[addr+1] )
  DUP CELL+ @ SWAP @ + ;

: TERM, ( n -- )
    NEXT-ADDR @ !
    NEXT-ADDR @ CELL + NEXT-ADDR ! ;

: LINE,
  NEXT-ADDR @
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
        
: .LINE ( addr,n -- )
    0 DO DUP I CELLS + @ . LOOP CR DROP ;
    
: .LINES ( addr,n -- ) 
    0 DO I SUM CELLS OVER + I 1+ .LINE LOOP DROP ;

CREATE TRIANGLE 20 SUM CELLS ALLOT
TRIANGLE NEXT-ADDR !
1 TERM, 
1 TERM, 1 TERM, 
23 LINES,

TRIANGLE 25 .LINES
BYE


