25 CONSTANT MAX-LINES
VARIABLE TERMS

: PREVIOUS ( addr -- addr' )
  CELL - ;

: ADD-TERMS ( addr -- addr[0]+addr[1] )
  DUP @ SWAP CELL+ @ + ;

: WRITE-TERM ( n -- )
  TERMS @ !
  CELL TERMS +! ;

: FIRST-TERM? ( addr -- f )
    @ 1 = ;

: WRITE-SUM ( addr -- )
    ADD-TERMS WRITE-TERM ;

: WRITE-LINE
  TERMS @
  PREVIOUS
  DUP @ WRITE-TERM
  BEGIN
    PREVIOUS
    DUP WRITE-SUM
    DUP FIRST-TERM?
  UNTIL
  @ WRITE-TERM ;

: WRITE-LINES ( n -- )
  0 DO WRITE-LINE LOOP ;

: SUM ( n -- n )
  0 SWAP 1+ 1 ?DO I + LOOP ;

: .TERMS ( addr,n -- )
  0 DO DUP I CELLS + @ . LOOP CR DROP ;

: LINE-ADDR ( addr,n -- addr )
  SUM CELLS + ;

: .LINE ( addr,n -- )
    TUCK LINE-ADDR SWAP 1+ .TERMS ;

: .LINES ( addr,n -- ) 
  0 DO DUP I .LINE LOOP DROP ;

CREATE TRIANGLE MAX-LINES SUM CELLS ALLOT
TRIANGLE TERMS !
1 WRITE-TERM
1 WRITE-TERM 1 WRITE-TERM
MAX-LINES 2 - WRITE-LINES

CR TRIANGLE MAX-LINES .LINES
BYE


