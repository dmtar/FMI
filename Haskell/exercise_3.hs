fact1 n = if n==0 then 1 else n * fact1 (n-1)
fact2 n
 |n == 0 = 1
 |otherwise = n * fact2 (n-1)
fact3 n = cycle 1 1
 where cycle i result 
        |i <= n               = cycle (i+1) (result*i) 
        |otherwise            = result 

pow x n 
 |n==0 = 1
 |n>0  = x*(pow x (n-1))
 |n<0  = 1/(pow x (-n))

pow2 x n = cycle 1 1
 where cycle i result
        |n<0          = 1/(pow2 x (-n))
        |n==0         = 1
        |i<=n         = cycle (i+1) (x*result)
        |otherwise    = result

qpow x n 
 |n==0                 = 1
 |n < 0                = 1/qpow x (-n)
 |even n               = y*y
 |otherwise            = x*qpow x (n-1)
  where y=qpow x (div n 2)

sumDigits n
 |n>0  = y + sumDigits z
 |n<0  = sumDigits (-n)
 |n==0 = 0 
  where y = mod n 10
        z = div n 10