#pragma once
#include <random>

#include "PrototypeGen.h"

class RandomGen : public PrototypeGen {
 public:
  RandomGen(std::string = "No name", std::string = "1");  //�����������

  int PushNum();
};