// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

/**
 * 
 */
UENUM()
enum EMovementType
{
	Lerp,
	ConstantLerp
};

UENUM()
enum EOffsetType
{
	World,
	Local
};