#include "ConststepGen.h"
#include "PrototypeGen.h"

ConststepGen::ConststepGen(std::string _name, std::string _N, int _step):PrototypeGen(_name, _N) ///конструктор
{
	SetStep(_step);
}

//ConststepGen::ConststepGen(ConststepGen& source)
//{
//	step = source.step;
//}
//
//ConststepGen& ConststepGen::operator=(const ConststepGen& source)
//{
//	step = source.step;
//	return *this;
//}
//
//ConststepGen::ConststepGen(ConststepGen&& other) noexcept
//	:step(std::exchange(other.step, NULL)) {}
//
//ConststepGen& ConststepGen::operator=(ConststepGen&& other) noexcept
//{
//	std::swap(step, other.step);
//	return *this;
//}

void ConststepGen::SetStep(int _step)
{
	if (_step == 0)
		throw std::invalid_argument("Шаг не может быть равен 0");
	else
		step = _step;
}



int ConststepGen::PushNum()
{
	std::random_device rd;
	std::mt19937 mersenne(rd());

	if (numbers.size() == 0)
		numbers.push_back(mersenne() % DIVIDER);
	else
		numbers.push_back(numbers.back() + step);
	return numbers.back();
}
