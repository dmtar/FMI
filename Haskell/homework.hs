koreni::Float->Float->Float->(Float,Float)
koreni a b c = if ((b^2 - 4*a*c)>0 && (a>0.0)) then (x1,x2) else (if (a==0.0 && b/=0.0) then (x,0.0) else error "Nqma realni koreni!")
 where x1=(-b + sqrt(b^2 - 4*a*c))/(2*a)
       x2=(-b - sqrt(b^2 - 4*a*c))/(2*a)
       x=c/b