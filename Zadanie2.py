conversionChoice = input("W jakich stopniach podajesz temperaturę? (C/F): ")
temperature = float(input("Podaj temperaturę: "))

if conversionChoice == "C":
    result = temperature*1.8+32
    print(f"{temperature}°C = {result}°F")
elif conversionChoice == "F":
    result = (temperature-32)/1.8
    print(f"{temperature}°F = {result}°C")
else:
    print("Błędny wybór skali")