#include "RandomGen.h"
#include "ConststepGen.h"
#include "CompositeGen.h"

void Menu() {
	int Gen, action, k, step, prev;
	std::string N;
	std::string name;
	RandomGen Rand;
	ConststepGen Const;
	CompositeGen Comp;
	std::cout << "Генераторы случайных чисел\nВыберите генератор : \n";
	std::cout << "(1) Случайный Генератор\n(2) ГенераторСПостояннымШагом\n(3) СоставнойГенератор\n";
	std::cin >> Gen;
	system("cls");
	switch (Gen) {
	case 1:
		while (1) {
			std::cout << "Выберите действие\n 1 – Дать имя\n 2 – Задать N\n 3 – Сгенерировать k чисел\n 4 – Среднее Арифметическое последних N чисел\n";
			std::cout << " 5 – Вернуть последнее значение\n 6 – Ввести последнее значение\n 7 – Выйти\n";
			std::cin >> action;
			switch (action) {
			default:
				std::cout << "Ошибка\n" << std::endl;
				break;
			case 1:
				std::cout << "Введите имя\n";
				std::cin >> name;
				try {
					Rand.SetName(name);
					std::cout << "Принято!\n";
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				break;
			case 2:
				std::cout << "Введите N\n";
				std::cin >> N;
				try {
					Rand.SetN(N);
					
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				std::cout << "Принято!\n";
				break;
			case 3:
				std::cout << "Введите k\n";
				std::cin >> k;
				if (k < 1) {
					std::cout << "k должно быть больше 1\n";
					break;
				}
				std::cout << std::endl;
				for (int i = 0; i < k; i++)
					std::cout << Rand.PushNum() << std::endl;
				std::cout << std::endl;
				break;
			case 4:
				try {
					Rand.Average();

				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				std::cout << "Среднее арифметическое: ";
				std::cout << Rand.Average() << std::endl << std::endl;
				break;
			case 5:
				std::cout << "Последнее значение: ";
				std::cout << Rand.GetPrev() << std::endl << std::endl;
				break;
			case 6:
				std::cout << "Введите последнее значение:\n";
				std::cin >> prev;
				
				try {
					Rand.SetPrev(prev);
					std::cout << "Последнее значение установлено\n" << std::endl;
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				break;
			case 7:
				return;
			}
		}
		break;
	case 2:
		while (1) {
			std::cout << "Выберите действие\n 1 – Дать имя\n 2 – Задать N\n 3 – Задать шаг\n 4 – Сгенерировать k чисел\n 5 – Среднее Арифметическое последних N чисел\n";
			std::cout << " 6 – Вернуть последнее значение\n 7 – Ввести последнее значение\n 8 – Выйти\n";

			std::cin >> action;
			switch (action) {
			default:
				std::cout << "Ошибка\n" << std::endl;
				break;
			case 1:
				std::cout << "Введите имя\n";
				std::cin >> name;
				try {
					Const.SetName(name);
					std::cout << "Принято!\n";
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				break;
			case 2:
				std::cout << "Введите N\n";
				std::cin >> N;
				try {
					Const.SetN(N);
					
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				std::cout << "Принято!\n";
				break;
			case 3:
				std::cout << "Введите шаг\n";
				std::cin >> step;
				try {
					Const.SetStep(step);
					std::cout << "Принято!\n";
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				break;
			case 4:
				std::cout << "Введите k\n";
				std::cin >> k;
				if (k < 1) {
					std::cout << "k должно быть больше 1\n";
					break;
				}
				std::cout << std::endl;
				for (int i = 0; i < k; i++)
					std::cout << Const.PushNum() << std::endl;
				std::cout << std::endl;
				break;
			case 5:
				std::cout << "Среднее арифметическое: ";
				std::cout << Const.Average() << std::endl << std::endl;
				break;
			case 6:
				std::cout << "Последнее значение: ";
				std::cout << Const.GetPrev() << std::endl << std::endl;
				break;
			case 7:
				std::cout << "Введите последнее значение:\n";
				std::cin >> prev;
				try {
					Const.SetPrev(prev);
					std::cout << "Последнее значение установлено\n" << std::endl;
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				break;
			case 8:
				return;
			}
		}
		break;
		case 3:
			while (1) {
				std::cout << "Выберите действие\n 1 – Дать имя\n 2 – Задать N\n 3 – Добавить случайный генератор\n 4 – Добавить генератор с постоянным шагом\n 5 – Сгенерировать число на основе ГСЧ и ГсПШ\n 6 – Среднее Арифметическое последних полученных N чисел\n";
				std::cout << " 7 – Удалить генератор по имени\n 8 – Выйти\n";

				std::cin >> action;
				switch (action) {
				default:
					std::cout << "Ошибка!\n" << std::endl;
					break;
				case 1:
					std::cout << "Введите имя\n";
					std::cin >> name;
					try {
						Comp.SetName(name);
						std::cout << "Принято!\n";
					}
					catch (const std::exception& ex) {
						std::cout << ex.what();
						return;
					}
					break;
				case 2:
					std::cout << "Введите N\n";
					std::cin >> N;
					try {
						Comp.SetN(N);
						
					}
					catch (const std::exception& ex) {
						std::cout << ex.what();
						return;
					}
					std::cout << "Принято!\n";
					break;
				case 3:
					std::cout << "Введите имя генератора\n";
					std::cin >> name;
					std::cout << "Введите количество генерируемых чисел\n";
					std::cin >> k;
					try {
						Comp.PushRG(name, k);
					}
					catch (const std::exception& ex) {
						std::cout << ex.what();
						return;
					}
					std::cout << "Генератор добавлен\n";
					break;
				case 4:
					std::cout << "Введите имя генератора\n";
					std::cin >> name;
					std::cout << "Введите количество генерируемых чисел\n";
					std::cin >> k;
					std::cout << "Введите шаг\n";
					std::cin >> step;
					try {
						Comp.PushCG(name, k, step);
					}
					catch (const std::exception& ex) {
						std::cout << ex.what();
						return;
					}
					std::cout << "Генератор добавлен\n";
					break;
				case 5:
					std::cout << "Число: ";
					std::cout << Comp.GetNum() << std::endl;
					break;
				case 6:
					std::cout << "Среднее арифметическое: ";
					std::cout << Comp.Average() << std::endl;
					break;
				case 7:
					std::cout << "Введите имя удаляемого генератора\n";
					std::cin >> name;
					Comp.DeleteGen(name);
					std::cout << "Генератор удален\n";
					break;
				case 8:
					return;
				}
			}
			break;
	default:
		std::cout << "Ошибка\n" << std::endl;
	}


}
int main() {
	setlocale(LC_ALL, "RU");
	system("cls");
	Menu();
}
