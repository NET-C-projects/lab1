#include "PrototypeGen.h"
#include <locale.h>

PrototypeGen::PrototypeGen(std::string _name, std::string _N)
{
	SetName(_name);
	SetN(_N);
}

//PrototypeGen::PrototypeGen(PrototypeGen& source)
//{
//	this->name = source.name;
//	this->N = source.N;
//	this->numbers = source.numbers;
//
//}
//
//PrototypeGen& PrototypeGen::operator=(const PrototypeGen& source)
//{
//	if (this != &source) {
//		this->name = source.name;
//		this->N = source.N;
//		this->numbers = source.numbers;
//	}
//	return *this;
//}
//
//PrototypeGen::PrototypeGen(PrototypeGen&& other) noexcept :name(other.name), N(other.N), numbers(other.numbers)
//{
//	other.name = "";
//	other.N = 0;
//	other.numbers = {};
//}
//
//PrototypeGen& PrototypeGen::operator=(PrototypeGen&& other) noexcept
//{
//	if (this == &other)
//		return *this;
//	std::swap(name, other.name);
//	std::swap(N, other.N);
//	std::swap(numbers, other.numbers);
//	return *this;
//}

void PrototypeGen::SetName(std::string _name)
{
	if (_name == "")
		throw std::invalid_argument("Имя не задано");
	else
		this->name = _name;

}

void PrototypeGen::SetN(std::string _N) {

	for (int i = 0; i < _N.size(); i++)
		if (!(_N[i] >= '0' || _N[i] <= '9' || _N[i] == '-'))
			Shortage = NotANumber;
	if (Shortage != NotANumber) {
		int temp = std::stoi(_N);
		if (temp <= 0)
			Shortage = Exception;
		else {
			N = temp;
			if (temp > numbers.size())
				Shortage = Count_Generated;
			else
				Shortage = Less;
		}
	}
	if(Shortage== NotANumber)
		throw std::invalid_argument("Введено не число");
	if (Shortage == Exception)
		throw std::invalid_argument("N меньше 1");
}

int PrototypeGen::Average() {
	int sum = 0;
		if (Shortage== Count_Generated)
		{
			for (auto iter = std::prev(numbers.end(),N); iter != numbers.end(); iter++)
				sum += *iter;
			return sum / N;
		}
		if(Shortage==Less)
		{
			for (auto iter = numbers.begin(); iter != numbers.end(); iter++)
				sum += *iter;
			return sum / numbers.size();
		}
	else
		if (Shortage==Exception)
			throw std::invalid_argument("N не может быть меньше единицы ");
		else
			throw std::out_of_range("Числа не были сгенерированы");
}

void PrototypeGen::SetPrev(int prev) {
	if (numbers.size() > 0)
		numbers.back() = prev;
	else
		throw std::out_of_range("Числа не были сгенерированы");
}

int PrototypeGen::GetPrev() {
	if (numbers.size() > 0)
		return numbers.back();
	else
		throw std::out_of_range("Числа не были сгенерированы");
}
