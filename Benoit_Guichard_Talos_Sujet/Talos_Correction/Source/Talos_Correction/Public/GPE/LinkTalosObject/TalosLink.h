// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "TalosLink.generated.h"

/**
 * 
 */

class  ATalosNode;

UCLASS()
class TALOS_CORRECTION_API UTalosLink : public UObject
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category ="Node") TObjectPtr<ATalosNode> from = nullptr;
	UPROPERTY(EditAnywhere, Category = "Node") TObjectPtr<ATalosNode> to = nullptr;
	UPROPERTY(VisibleAnywhere, Category = "Node") bool isLinkedToSource = false;
	UPROPERTY(VisibleAnywhere, Category = "Node") bool isValid = false;
public:
	void Connect(TObjectPtr<ATalosNode> _from, TObjectPtr<ATalosNode> _to);
	void Debug();
	void Run();
	bool IsValidLink(TArray<TEnumAsByte<EObjectTypeQuery>> _validLayer);
};
