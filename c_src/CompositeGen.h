#pragma once
#include <forward_list>
#include <memory>
#include <unordered_map>

#include "ConststepGen.h"
#include "RandomGen.h"

class CompositeGen : public PrototypeGen {
 public:
  CompositeGen(std::string = "No name", std::string = "1", int = 0);
  int GetNum();
  void PushRG(const std::string, int);
  void PushCG(std::string, int, int);
  void DeleteGen(std::string);
  int Average();

 private:
  std::unordered_map<std::string, std::shared_ptr<RandomGen> > RGarr;
  std::unordered_map<std::string, std::shared_ptr<ConststepGen> > CGarr;
  std::forward_list<int> Averarr;
  int counter;
};
