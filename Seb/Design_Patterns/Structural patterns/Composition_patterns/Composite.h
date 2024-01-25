#pragma once
#include "Leaf.h"
#include "Component.h"
/*
class Composite : public Component
{
private:
	std::vector< Component> children = std::vector< Component>();
	std::vector< Composite> composites = std::vector< Composite>();
	std::vector< Leaf> leafs = std::vector< Leaf>();
public:
	inline std::vector< Component> GetChildren() const { return children; }
	inline std::vector< Composite> GetComposites() const {return composites; }
	inline std::vector< Leaf> GetLeafs() const { return leafs; }
	void DrawPrice() override;
	void ReturnPrice()override;
};

*/