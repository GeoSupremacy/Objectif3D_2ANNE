

#include "GUI/BaseUserWidget.h"

void UBaseUserWidget::NativeConstruct()
{
	Super::NativeConstruct();
	Bind();
	bIsFocusable = true;
}

void UBaseUserWidget::Bind()
{
}
