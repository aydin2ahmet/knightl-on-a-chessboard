# KnightL on a Chessboard

KnightL is a chess piece that moves in an L shape. We define the possible moves of KnightL(a, b) as any movement from some position (x1, yi) to some (x2, y2) satisfying either of the following:
• x2 = x1 ± a and y2 =y1 ± b, or
• x2 = xl ± b and y2= y1 ± a


Observe that for each possible movement, the Knight moves 2 units in one direction (i.e., horizontal or vertical) and 1 unit in the perpendicular direction.Given the value of n, for an n x it chessboard, answer the following question for each (a, b) pair where 1 < a, b < n:
• What is the minimum number of moves it takes for KnightL(a,b) to get from position (0, 0) to position (n — 1,n — 1)? If its not possible for the Knight to reach that destination, the answer is -1 instead.Then print the answer for each KnightL(a, b) according to the Output Format specified below.


Input Format 
A single integer denoting n. 


Print exactlyn —1 lines of output in which each line % (where 1 < < n) contains n — 1 space-separated integers describing the minimum number of moves KnightL(i, j) must make for each respective j (where 1 < j < n). If some KnightL(i, j) cannot reach position (n - 1,n — 1), print -I instead. For example, if it = 3, we organize the answers for all the j) pairs in our output like this: 
(1,1) (1,2) (2,1) (2,2) 
