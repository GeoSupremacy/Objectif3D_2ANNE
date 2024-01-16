// Fill out your copyright notice in the Description page of Project Settings.


#include "FSM/BasicTransitions/WaitTransition.h"

void UWaitTransition::InitTranstition()
{
	waitTime = FMath::FRandRange(minTime, maxTime);
	GetWorld()->GetTimerManager().SetTimer(waitTimer, this, &UWaitTransition::Wait, waitTime, false);
}

bool UWaitTransition::IsValidTranstition()
{
	return isDone;
}

void UWaitTransition::Wait()
{
	isDone = true;
}
