#pragma once
#include <iostream>
#include <list>
#include <string>
const int DIVIDER = 100;
enum ShortageOfNumbers { Count_Generated, Exception, NotANumber, Less };
class PrototypeGen {
  friend class CompositeGen;

 public:
  PrototypeGen(std::string = "No name", std::string = "1");

  void SetName(std::string);
  void SetN(std::string);
  void SetPrev(int);
  int GetPrev();
  virtual int Average();

 protected:
  std::string name;
  std::list<int> numbers;
  int N;
  ShortageOfNumbers Shortage;
};
