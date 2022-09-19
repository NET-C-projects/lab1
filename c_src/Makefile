.PHONY: all, clean, rebuild, extra

CC = g++
CFLAGS = -c
STDFLAGS = -std=c++1z

BUILD_PATH = 

SOURCES = CompositeGen.cpp ConststepGen.cpp PrototypeGen.cpp RandomGen.cpp Source.cpp
OBJECTS = $(SOURCES:.cpp=.o)

EXECUTABLE = MAIN

all: $(OBJECTS)
	$(CC) $(BUILD_PATH)$(OBJECTS) -o $(BUILD_PATH)$(EXECUTABLE) $(STDFLAGS)

rebuild: clean all

rebuild_extra: clean extra

%.o: %.cpp
	$(CC) $(CFLAGS) $< -o $(BUILD_PATH)$@

clean:
	-rm  $(BUILD_PATH)*.o
