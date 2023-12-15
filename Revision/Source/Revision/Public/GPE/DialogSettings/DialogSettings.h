// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "DialogSettings.generated.h"

USTRUCT()
struct FAnswers
{

	GENERATED_BODY()
	
	UPROPERTY(EditAnywhere)
		FString answer;
	
	
};

USTRUCT()
struct FDialog
{
	GENERATED_BODY()
		UPROPERTY(EditAnywhere)
		FString quote;
	UPROPERTY(EditAnywhere)
		TArray<FAnswers> answers;

	FAnswers Choice(int _index) { return answers[_index]; }
	int Count() const {return answers.Num(); }
};
UCLASS()
class REVISION_API UDialogSettings : public UDataAsset
{
	GENERATED_BODY()
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnCallback, FDialog, _callback);
	FOnCallback onCallback;
	
private:
	UPROPERTY(EditAnywhere)
		TArray<FDialog> dialogs;
	UPROPERTY(EditAnywhere)
		FString id = "ID";
	int dialogProgress = 0;
public:
	FORCEINLINE FString GetID()  const { return id; }
	FORCEINLINE int GetDialogProcess()  const{ return dialogProgress; }
	FORCEINLINE void SetDialogProcess(int _index) { dialogProgress = _index; }

	FORCEINLINE FDialog Dialog(int index) { return dialogs[index]; }
	FORCEINLINE FDialog CurrentDialogs() const { return dialogs[dialogProgress]; }
	FORCEINLINE int Count() const { return dialogs.Num(); }

	FORCEINLINE TArray< FDialog> Dialogs() const { return dialogs; }
	FORCEINLINE	int CountAllAnswers(int _index) const { return dialogs[_index].Count();}
	FORCEINLINE TArray<FAnswers> AllAnswers(int _index) const { return dialogs[_index].answers; }
public:
	FORCEINLINE FOnCallback& OnCallback()  { return onCallback; }
};
