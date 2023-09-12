# SinSigGenerator

Данный API интерфейс решает проблему построения синусоидального сигнала из полученных данных. На вход данной программе подаются: амплитуда, частота сигнала в герцах и дескритизации, а также количество периодов. Посредством POST - запроса полученные данные отправляются в SignalGeneratorService, где генирируется BitMap размером 1920х1080p, выстраиваются оси ординат и абсцисс при помощи пространства имен System.Drawing. Далее следует логика получения координат точек, полученных на основе входных данных, и последущее отображение найденных точек на координатной плоскости. Полученное BitMap изображение возвращается в SignalController в виде преобразованной модели ImageModel, которая сохраняется локально на устройстве. SignalController же в свою очередь обрабатывает полученную модель и возвращает ответ, содержащий файл, который доступен к скачиванию. Так же предусмотрены кастомные исключения, которые гарантируют получение и верность входных параметров.