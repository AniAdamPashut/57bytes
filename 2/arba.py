import matplotlib.pyplot as plt
from scipy import stats


def get_number() -> int:
    number = input('Enter a number (-1) to quit: ')
    try:
        return int(number)
    except ValueError:
        print('Please enter a valid number')
        return get_number()


def recv_numbers() -> list[int]:
    number = get_number()
    numbers = list()
    while number != -1:
        numbers.append(number)
        number = get_number()
    return numbers

def avg(numbers: list[int]) -> float:
    return sum(numbers) / len(numbers)

def how_many_pos(numbers: list[int]) -> int:
    return len([x for x in numbers if x > 0])

def display_plot(numbers: list[int]):
    plt.plot(numbers, 'ro')
    plt.ylabel('input')
    plt.show()

def pearson(numbers: list[int]) -> int:
    return stats.pearsonr(x=numbers, y=list(range(len(numbers))))

def main():
    numbers = recv_numbers()
    print('Average:', avg(numbers))
    print('The amount of positive numbers is:', how_many_pos(numbers))
    print('The list of numbers sorted is:', list(sorted(numbers)))
    print('The PCC is:', pearson(numbers))
    display_plot(numbers)

if __name__ == '__main__':
    main()
