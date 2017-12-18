#include "Stdafx.h"

#ifndef XMLPARSE_H
#define XMLPARSE_H

#include <string>
#include <stdio.h>

namespace ELM_GUI_lib {

public class XMLParse {
public:
    
    enum XML_TAGS {
        
        CONNECTS_START,
        CONNECT,
        CONNECTS_END,
        
        GENERIC_NAME_PACKAGE,
        GENERIC_NAME_SYMBOL,
        GENERIC_VALUE_SYMBOL,
        
        DEVICE_START,
        DEVICE_END,
        DEVICES_START,
        DEVICES_END,
        DEVICESET_START,
        DEVICESET_END,
        DEVICESETS_START,
        DEVICESETS_END,
        
        SYMBOL_START,
        SYMBOL_END,
        
        PACKAGE_START,
        PACKAGE_END,
        PACKAGES_START,
        PACKAGES_END,
        
        TECHNOLOGIES_START,
        TECHNOLOGIES_END,
        TECHNOLOGY,
        
        GATES_START,
        GATE,
        GATES_END,
        
        LAYERS_END,
        DRAWING_END        
    };
    
    static std::string generateTag(XML_TAGS TAG, std::string param = "");
    
    XMLParse();
    XMLParse(const XMLParse& orig);
    virtual ~XMLParse();
    
    static std::string nameFromXML(std::string XML_in);
    static std::string tagWrapXML(std::string XML_in, std::string start, std::string end);
    static std::string numToString(double x);
    static std::string numToString(int x);
    
private:

};

}
#endif /* XMLPARSE_H */