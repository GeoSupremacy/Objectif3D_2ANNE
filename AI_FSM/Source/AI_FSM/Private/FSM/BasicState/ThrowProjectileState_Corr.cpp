// Fill out your copyright notice in the Description page of Project Settings.

#include "FSM/FSMObject.h"
#include "../../../FSM/FSMComponent.h"
#include "FSM/BasicTransitions/WaitProjectileKillTransition_Cor.h"
#include "FSM/BasicState/ThrowProjectileState_Corr.h"

void UThrowProjectileState_Corr::Enter(UFSMObject* _owner)
{
	Super::Enter(_owner);
	if (!projectile)
		return;
	AActor* _projectile =GetWorld()->SpawnActor<AActor>(projectile, _owner->GetOwner()->GetOwner()->GetActorLocation(), FRotator(0));
	_projectile->SetLifeSpan(2);
	if (waitForKill)
		waitForKill->SendProjectile(_projectile);
}

void UThrowProjectileState_Corr::InitTransitions()
{
	Super::InitTransitions();
	for (size_t i = 0; i < runningTransitions.Num(); i++)
	{
		
		UWaitProjectileKillTransition_Cor* _wait = Cast< UWaitProjectileKillTransition_Cor>(runningTransitions[i]);
		if (_wait)
		{
			waitForKill = _wait;
			return;
		}
		
	}
	//TODO find if exist->waitforZobi
}
