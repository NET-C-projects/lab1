#pragma once
#include <string>
#include <iostream>
#include <random>
#include <vector>
#include "PrototypeGen.h"

class ConststepGen : public PrototypeGen
{
public:
	friend class CompositeGen;
	ConststepGen(std::string = "No name", std::string = "1", int = 1); //конструктор

	//ConststepGen(ConststepGen& source); //копирование инициализация
	//ConststepGen& operator = (const ConststepGen& source); // присваивание копирование
	//ConststepGen(ConststepGen&& other) noexcept;// перемещаем конструктор
	//ConststepGen& operator=(ConststepGen&& other) noexcept;  // перемещаем присвоение

	void SetStep(int);
	int PushNum();

	//~ConststepGen(){}

private:
	int step;

};