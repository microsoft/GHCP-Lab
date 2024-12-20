using SOC.AdvancedCopilot.DotNet;


class Program
{
    static void Main(string[] args)
    {
        var alerts = Mocks.MockedAlerts.GetMockedAlerts();

        // In this exercise you should only be using *completions*. Do not use inline chat / chat
        GHCPCompletions.OnlyCompletions(alerts);
        // In this exercise you should only be using *inline chat*. Do not use completions / chat
        GHCPInlineChat.OnlyInlineChat();
        // In this exercise you should only be using Chat. Do not use completions / inline chat
        GHCPChat.OnlyChat();


    }
}






























































// SECRET: you

