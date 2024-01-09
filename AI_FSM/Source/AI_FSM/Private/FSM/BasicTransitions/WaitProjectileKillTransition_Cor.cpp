// Fill out your copyright notice in the Description page of Project Settings.


#include "FSM/BasicTransitions/WaitProjectileKillTransition_Cor.h"

void UWaitProjectileKillTransition_Cor::SendProjectile(AActor* _projectile)
{
	currentProjectile = _projectile;
}

bool UWaitProjectileKillTransition_Cor::IsValidTranstition()
{
	return currentProjectile->IsActorBeingDestroyed();
}
