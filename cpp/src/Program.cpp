#include "CommonHeaders.h"
#include "Completions.h"
#include "Chat.h"
#include "InlineChat.h"
#include "MockedAlerts.h"

using namespace AdvancedCopilot::cpp;

void main()
{
        auto alerts = MockedAlerts::GetMockedAlerts();

        // In this exercise you should only be using *completions*. Do not use inline chat / chat
        GHCPCompletions::OnlyCompletions(alerts);
        // In this exercise you should only be using *inline chat*. Do not use completions / chat
        GHCPInlineChat::OnlyInlineChat();
        // In this exercise you should only be using Chat. Do not use completions / inline chat
        GHCPChat::OnlyChat();
}