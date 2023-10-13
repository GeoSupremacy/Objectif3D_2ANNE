#pragma once
#include <vector>
#include "EngineObject.h"

using namespace std;
class Content
{
private:
	vector<EngineObject*> engineObjects;
public:
	inline vector<EngineObject*>Get() const { return engineObjects; }
	Content();
	~Content();
};

