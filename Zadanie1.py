a = float(input("Podaj pierwszą liczbę: "))
b = float(input("Podaj drugą liczbę: "))
operation = input("Wybierz działanie (+, -, *, /): ")

if operation == "+":
    result = a+b
elif operation == "-":
    result = a-b
elif operation == "*":
    result = a*b
elif operation == "/":
    if b != 0:
        result = a/b
    else:
        print("Nie można dzielić przez zero")
        exit()
else:
    print("Błędny znak")
    exit()

print("Wynik: ", result)