# MultiThread
MultiThread - многопоточное консольное приложение

Задание:

Есть несколько заводов, каждый из которых выпускает продукцию одного типа. Например, завод A выпускает продукт "a", завод B - продукт "b" и т.д.
Каждый завод выпускает разное количество своей продукции. Завод А - n единиц в час, B - 1.1*n единиц в 1 час, С - 1.2*n единиц продукции в час и т.д. 
Размерами продукции пренебрегаем и предполагаем одинаковыми для всех фабрик, однако каждый продукт имеет уникальные свойства: название, вес, тип упаковки.

Необходимо организовать эффективное складирование продукции заводов, а также доставку в торговые сети из расчёта, что склад может вмещать 
M * N (сумму продукции всех фабрик в час). 
По заполнению склада не менее чем на 95% склад должен начинать освобождаться от продукции следующим образом. Продукцию со склада забирает грузовой транспорт различной вместимости (не менее двух видов грузовиков). Грузовик может забирать продукцию разных типов.
М может быть переменным, но не менее 100. Число заводов может быть переменным, но не менее трёх. n может быть переменным, но не менее 50.

Необходимо вывести следующие результаты работы алгоритма:

- последовательность поступления продукции на склад (фабрика, продукт, число единиц).

- необходимо подсчитать статистику, сколько продукции и какого состава в среднем перевозят грузовики.

 Приложение предлагается реализовать многопоточным.
