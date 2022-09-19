#include "RandomGen.h"

RandomGen::RandomGen(std::string _name, std::string _N) :PrototypeGen(_name,_N){}



int RandomGen::PushNum() {
	std::random_device rd;
	std::mt19937 mersenne(rd());

	numbers.push_back(mersenne() % DIVIDER);
	return numbers.back();
}

