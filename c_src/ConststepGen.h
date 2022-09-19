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
	ConststepGen(std::string = "No name", std::string = "1", int = 1); //�����������

	//ConststepGen(ConststepGen& source); //����������� �������������
	//ConststepGen& operator = (const ConststepGen& source); // ������������ �����������
	//ConststepGen(ConststepGen&& other) noexcept;// ���������� �����������
	//ConststepGen& operator=(ConststepGen&& other) noexcept;  // ���������� ����������

	void SetStep(int);
	int PushNum();

	//~ConststepGen(){}

private:
	int step;

};