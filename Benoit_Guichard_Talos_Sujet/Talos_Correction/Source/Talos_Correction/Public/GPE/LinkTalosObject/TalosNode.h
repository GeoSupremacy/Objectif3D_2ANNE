// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "TalosLink.h"
#include "Engine/StaticMeshActor.h"
#include "TalosNode.generated.h"

/**
 * 
 */
UCLASS(Abstract, Blueprintable)
class TALOS_CORRECTION_API ATalosNode : public AStaticMeshActor
{
	GENERATED_BODY()
protected:
	UPROPERTY(EditAnywhere, Category = "All Links") FColor nodeColor = FColor::Red;
	UPROPERTY(VisibleAnywhere, Category ="All Links", meta =(EditInLine)) TMap<FString, UTalosLink*> connectedNode = {};
	UPROPERTY(EditAnywhere, Category = "All Links") bool isSource = false;
	UPROPERTY(VisibleAnywhere, Category = "All Links") int id =0;
	UPROPERTY(EditAnywhere, Category = "All Links") TArray<TEnumAsByte<EObjectTypeQuery>> validLayer;
public:
	FORCEINLINE bool IsSource() const {return isSource;}
	FORCEINLINE void SetSource(const bool &_isSource) {  isSource = _isSource; }
	FORCEINLINE int GetID() const { return id; }
	UFUNCTION(BlueprintCallable) void AddLink(ATalosNode* _otherNode);
	virtual void NodeBehaviour();
	
	ATalosNode();
	virtual void BeginPlay() override;
	virtual void Tick(float _detaTime) override;

};
