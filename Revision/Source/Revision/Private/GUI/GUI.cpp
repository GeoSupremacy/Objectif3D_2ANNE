// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/GUI.h"

void UGUI::NativeConstruct()
{
	Super::NativeConstruct();
	Bind();
	bIsFocusable = true;
}

void UGUI::Bind()
{
}
