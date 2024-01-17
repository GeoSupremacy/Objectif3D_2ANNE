// Fill out your copyright notice in the Description page of Project Settings.



#include "IA/PointByWay.h"


APointByWay::APointByWay()
{
    PrimaryActorTick.bCanEverTick = true;

    icon = CreateDefaultSubobject<UBillboardComponent>("Icon");
    RootComponent = icon;
}



