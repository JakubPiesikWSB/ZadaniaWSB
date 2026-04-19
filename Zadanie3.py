n = int(input("Ile ocen zdobył uczeń: "))
suma = 0

for i in range(n):
    grade = float(input(f"Podaj ocenę nr. {i+1}: "))
    suma = suma + grade

avg = suma / n
print(f"Średnia: {avg:.2f}")

if avg >= 3.0:
    print("Uczeń zdał")
else:
    print("Uczeń nie zdał")