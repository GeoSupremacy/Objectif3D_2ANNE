// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/DialogSettings/DialogSettings.h"

#include "GameFramework/Actor.h"
#include "PNJ.generated.h"

UCLASS()
class REVISION_API APNJ : public AActor
{
	GENERATED_BODY()
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnOpenChat,FString, _id);
	FOnOpenChat onOpenChat;
private:
	UPROPERTY(EditAnywhere, Category ="Dialogs")
		TObjectPtr<UDialogSettings> dialogSettings;
	bool thisPNJ = false;
public:	
	APNJ();
	FORCEINLINE TObjectPtr<UDialogSettings> DialogSettings() const { return dialogSettings; }
	FORCEINLINE FOnOpenChat& OnOpenChat() { return onOpenChat; }
	FORCEINLINE bool ThisPNJ()  const { return thisPNJ; }
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	UFUNCTION() void OpenChat(FString _id);
	UFUNCTION()  void LeftChat();
	void Bind();
};
