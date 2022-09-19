#include "CompositeGen.h"

CompositeGen::CompositeGen(std::string _name,std::string _N, int _counter) :PrototypeGen(_name, _N)
{
	counter = _counter;
}

int CompositeGen::GetNum()
{	
	int sum = 0, size = 0;
	for (auto it = RGarr.begin(); it != RGarr.end(); it++) {
		for (auto iter = (it->second)->numbers.begin(); iter != it->second->numbers.end(); iter++) {
			size++;
			sum += *iter;
		}
	}
	for (auto it = CGarr.begin(); it != CGarr.end(); ++it) {
		for (auto iter = it->second->numbers.begin(); iter != it->second->numbers.end(); iter++) {
			size++;
			sum += *iter;
		}
	}
	return size==0?0:sum / size;

}

void CompositeGen::PushRG(  std::string _name, int _size)
{
	if(_size<0)
		throw std::invalid_argument("���������� ����� �������������");
	auto temp =std::make_shared<RandomGen>() ;
	temp.get()->SetName(_name);

	for (int i = 0; i < _size; i++) {
		int t = temp.get()->PushNum();
		std::cout << t << std::endl;
		Averarr.push_front(t);
		if (counter <= N)
			counter++;
		else 
			Averarr.erase_after(std::next(Averarr.begin(), N));
	}	
	RGarr.insert(std::make_pair(_name, temp));
}

void CompositeGen::PushCG(std::string _name, int _size,int _step)
{
	if (_size < 0)
		throw std::invalid_argument("���������� ����� �������������");
	auto temp = std::make_shared<ConststepGen>();
	temp.get()->SetName(_name);
	temp.get()->SetStep(_step);

	for (int i = 0; i < _size; i++) {
		int t = temp.get()->PushNum();
		std::cout << t << std::endl;
		Averarr.push_front(t);
		if (counter <= N)
			counter++;
		else
			Averarr.erase_after(std::next(Averarr.begin(), N));
	}
	CGarr.insert(std::make_pair(_name, temp));
}


void CompositeGen::DeleteGen(std::string _name)
{
	if(RGarr.end() != RGarr.find(_name))
		RGarr.erase(_name);
	if (CGarr.end() != CGarr.find(_name))
		CGarr.erase(_name);
}

int CompositeGen::Average()
{
	int sum = 0,size = N;
	if (Shortage == Count_Generated) {
		size = 0;
		for (auto iter = Averarr.begin(); iter != Averarr.end(); iter++) {
			size++;
			sum += *iter;
		}
	}
	if(Shortage==Less)
		for (auto iter = Averarr.begin(); iter!=Averarr.end(); iter++)
			sum += *iter; 
	return size==0?0:sum / size;
}