// ELM_GUI_lib.h

#include "XMLParse.h"
#include "Symbol.h"
#include "SMD.h"
#include "PIN.h"
#include "Package.h"
#include "ELM.h"
#include "Device.h"

#pragma once

using namespace System;

namespace ELM_GUI_lib {

	//C++: string to char[] (std::string.c_str())
	//C++: string[] to char[]
	//C++: char[] to string (std::string mystring = thatcharbuffer)
	//C++: char[] to string[]

	public class INTEROP_DRIVER {
	public:
		static char* stringArrayToCharArray(std::vector<std::string> stringsIn);
		static void clear_charbuf(char charsIn[], int len);
		static std::vector<std::string> charArrayToStringArray(char* charsIn);

		static std::vector<double> doublePtrToDoubleVec(double* dvec, int length);
		static std::vector<int> intPtrToIntVec(int* iptr, int length);
	};

}