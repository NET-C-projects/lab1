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
	std::cout << "���������� ��������� �����\n�������� ��������� : \n";
	std::cout << "(1) ��������� ���������\n(2) �������������������������\n(3) ������������������\n";
	std::cin >> Gen;
	system("cls");
	switch (Gen) {
	case 1:
		while (1) {
			std::cout << "�������� ��������\n 1 � ���� ���\n 2 � ������ N\n 3 � ������������� k �����\n 4 � ������� �������������� ��������� N �����\n";
			std::cout << " 5 � ������� ��������� ��������\n 6 � ������ ��������� ��������\n 7 � �����\n";
			std::cin >> action;
			switch (action) {
			default:
				std::cout << "������\n" << std::endl;
				break;
			case 1:
				std::cout << "������� ���\n";
				std::cin >> name;
				try {
					Rand.SetName(name);
					std::cout << "�������!\n";
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				break;
			case 2:
				std::cout << "������� N\n";
				std::cin >> N;
				try {
					Rand.SetN(N);
					
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				std::cout << "�������!\n";
				break;
			case 3:
				std::cout << "������� k\n";
				std::cin >> k;
				if (k < 1) {
					std::cout << "k ������ ���� ������ 1\n";
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
				std::cout << "������� ��������������: ";
				std::cout << Rand.Average() << std::endl << std::endl;
				break;
			case 5:
				std::cout << "��������� ��������: ";
				std::cout << Rand.GetPrev() << std::endl << std::endl;
				break;
			case 6:
				std::cout << "������� ��������� ��������:\n";
				std::cin >> prev;
				
				try {
					Rand.SetPrev(prev);
					std::cout << "��������� �������� �����������\n" << std::endl;
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
			std::cout << "�������� ��������\n 1 � ���� ���\n 2 � ������ N\n 3 � ������ ���\n 4 � ������������� k �����\n 5 � ������� �������������� ��������� N �����\n";
			std::cout << " 6 � ������� ��������� ��������\n 7 � ������ ��������� ��������\n 8 � �����\n";

			std::cin >> action;
			switch (action) {
			default:
				std::cout << "������\n" << std::endl;
				break;
			case 1:
				std::cout << "������� ���\n";
				std::cin >> name;
				try {
					Const.SetName(name);
					std::cout << "�������!\n";
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				break;
			case 2:
				std::cout << "������� N\n";
				std::cin >> N;
				try {
					Const.SetN(N);
					
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				std::cout << "�������!\n";
				break;
			case 3:
				std::cout << "������� ���\n";
				std::cin >> step;
				try {
					Const.SetStep(step);
					std::cout << "�������!\n";
				}
				catch (const std::exception& ex) {
					std::cout << ex.what();
					return;
				}
				break;
			case 4:
				std::cout << "������� k\n";
				std::cin >> k;
				if (k < 1) {
					std::cout << "k ������ ���� ������ 1\n";
					break;
				}
				std::cout << std::endl;
				for (int i = 0; i < k; i++)
					std::cout << Const.PushNum() << std::endl;
				std::cout << std::endl;
				break;
			case 5:
				std::cout << "������� ��������������: ";
				std::cout << Const.Average() << std::endl << std::endl;
				break;
			case 6:
				std::cout << "��������� ��������: ";
				std::cout << Const.GetPrev() << std::endl << std::endl;
				break;
			case 7:
				std::cout << "������� ��������� ��������:\n";
				std::cin >> prev;
				try {
					Const.SetPrev(prev);
					std::cout << "��������� �������� �����������\n" << std::endl;
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
				std::cout << "�������� ��������\n 1 � ���� ���\n 2 � ������ N\n 3 � �������� ��������� ���������\n 4 � �������� ��������� � ���������� �����\n 5 � ������������� ����� �� ������ ��� � ����\n 6 � ������� �������������� ��������� ���������� N �����\n";
				std::cout << " 7 � ������� ��������� �� �����\n 8 � �����\n";

				std::cin >> action;
				switch (action) {
				default:
					std::cout << "������!\n" << std::endl;
					break;
				case 1:
					std::cout << "������� ���\n";
					std::cin >> name;
					try {
						Comp.SetName(name);
						std::cout << "�������!\n";
					}
					catch (const std::exception& ex) {
						std::cout << ex.what();
						return;
					}
					break;
				case 2:
					std::cout << "������� N\n";
					std::cin >> N;
					try {
						Comp.SetN(N);
						
					}
					catch (const std::exception& ex) {
						std::cout << ex.what();
						return;
					}
					std::cout << "�������!\n";
					break;
				case 3:
					std::cout << "������� ��� ����������\n";
					std::cin >> name;
					std::cout << "������� ���������� ������������ �����\n";
					std::cin >> k;
					try {
						Comp.PushRG(name, k);
					}
					catch (const std::exception& ex) {
						std::cout << ex.what();
						return;
					}
					std::cout << "��������� ��������\n";
					break;
				case 4:
					std::cout << "������� ��� ����������\n";
					std::cin >> name;
					std::cout << "������� ���������� ������������ �����\n";
					std::cin >> k;
					std::cout << "������� ���\n";
					std::cin >> step;
					try {
						Comp.PushCG(name, k, step);
					}
					catch (const std::exception& ex) {
						std::cout << ex.what();
						return;
					}
					std::cout << "��������� ��������\n";
					break;
				case 5:
					std::cout << "�����: ";
					std::cout << Comp.GetNum() << std::endl;
					break;
				case 6:
					std::cout << "������� ��������������: ";
					std::cout << Comp.Average() << std::endl;
					break;
				case 7:
					std::cout << "������� ��� ���������� ����������\n";
					std::cin >> name;
					Comp.DeleteGen(name);
					std::cout << "��������� ������\n";
					break;
				case 8:
					return;
				}
			}
			break;
	default:
		std::cout << "������\n" << std::endl;
	}


}
int main() {
	setlocale(LC_ALL, "RU");
	system("cls");
	Menu();
}
