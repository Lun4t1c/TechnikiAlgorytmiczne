from threading import Thread

import matplotlib.pyplot as plt


SET_RESULTS_FILE_PATH_1 = 'bin\\Debug\\net6.0\\OperationsSet1.txt'
SET_RESULTS_FILE_PATH_2 = 'bin\\Debug\\net6.0\\OperationsSet2.txt'
SET_RESULTS_FILE_PATH_3 = 'bin\\Debug\\net6.0\\OperationsSet3.txt'

SET_RESULTS_SPLAY_FILE_PATH_1 = 'bin\\Debug\\net6.0\\OperationsSetSplay1.txt'
SET_RESULTS_SPLAY_FILE_PATH_2 = 'bin\\Debug\\net6.0\\OperationsSetSplay2.txt'
SET_RESULTS_SPLAY_FILE_PATH_3 = 'bin\\Debug\\net6.0\\OperationsSetSplay3.txt'

def draw_chart_from_file_path(path: str, title: str):
    array_amounts = []
    array_operations_insert = []
    array_operations_find = []
    array_operations_delete = []
    array_heights = []

    for line in open(path):
        line = line.split(';')
        array_amounts.append(int(line[0]))
        array_operations_insert.append(float(line[1]))
        array_operations_find.append(float(line[2]))
        array_operations_delete.append(float(line[3]))
        array_heights.append(int(line[4]))

    print(array_amounts)
    print(array_operations_insert)
    print(array_operations_find)
    print(array_operations_delete)
    print(array_heights)

    plt.title(title)
    plt.xlabel("Liczba elementów w drzewie")
    plt.ylabel("Liczba operacji")

    # plt.plot(array_amounts, array_heights, label='Wysokość drzewa')
    plt.plot(array_amounts, array_operations_insert, label='Wstawianie')
    plt.plot(array_amounts, array_operations_find, label='Znajdowanie')
    plt.plot(array_amounts, array_operations_delete, label='Usuwanie')

    plt.legend(loc="upper left")
    # plt.show()
    plt.savefig(title + '.png')
    plt.close()


draw_chart_from_file_path(SET_RESULTS_FILE_PATH_1, 'Zbiór 1')
draw_chart_from_file_path(SET_RESULTS_FILE_PATH_2, 'Zbiór 2')
draw_chart_from_file_path(SET_RESULTS_FILE_PATH_3, 'Zbiór 3')

draw_chart_from_file_path(SET_RESULTS_SPLAY_FILE_PATH_1, 'Zbiór 1 (splay)')
draw_chart_from_file_path(SET_RESULTS_SPLAY_FILE_PATH_2, 'Zbiór 2 (splay)')
draw_chart_from_file_path(SET_RESULTS_SPLAY_FILE_PATH_3, 'Zbiór 3 (splay)')

