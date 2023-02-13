def digui(i):
    if i == 1:
        return 1
    return i + digui(i - 1)

print(digui(50))

def TestRange():
    for i in range(5):
        print(i)

TestRange()