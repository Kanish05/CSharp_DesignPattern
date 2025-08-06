/*
🏦 Problem Statement: "Bank Loan Approval System"
You are building a loan approval system in a bank. When a customer applies for a loan, the system must do several checks before approving the loan:

Subsystems (Internal Services):
CreditCheckService – Verifies the applicant’s credit score.

AccountService – Checks if the applicant has a valid account and enough balance.

LoanHistoryService – Checks if the applicant has any past loan defaults.

Your Task:
Create a LoanApprovalFacade class that simplifies these complex checks.

The client should just call IsEligible(string customerName) method from the facade to know if the loan can be approved.

Implement proper console outputs to show which checks are being done.

Return a final result: either "Loan Approved" or "Loan Denied".

📝 Example Output:
vbnet
Copy
Edit
Checking loan eligibility for Alice...

Checking credit score...
Credit score is good.

Checking account status...
Account is active with sufficient balance.

Checking loan history...
No previous loan defaults.

Result: Loan Approved
*/
using System;
using System.Text;

public class CreditCheckService {
    public string GetCreditScore() =>  "Credit Score is Good";
}

public class AccountService {
    public string GetAccountService() =>  "Account is active with sufficient balance.";
}

public class LoanHistoryService {
     public string GetHistory() =>  "No previous loan defaults.";
}

public class LoanApprovalFacade {
    private CreditCheckService _creditScore;
    private AccountService _account;
    private LoanHistoryService _history;
    
    public LoanApprovalFacade(CreditCheckService creditScore , AccountService account ,LoanHistoryService history){
        _creditScore = creditScore;
        _account = account;
        _history = history;
        
    }
    
    public string IsEligible(string customerName){
        StringBuilder sb = new StringBuilder();
        sb.Append("Checking loan eligibility for "+customerName + "\n");
        sb.Append("Checking credit score..."+ "\n");
        sb.Append(_creditScore.GetCreditScore()+ "\n");
        sb.Append("Checking account status..."+"\n");
        sb.Append(_account.GetAccountService()+ "\n");
        sb.Append("Checking loan history..."+"\n");
        sb.Append(_history.GetHistory()+ "\n");
        return sb.ToString();
    }
}

class Program{
    public static void Main(string[] args){
        CreditCheckService creditScore = new CreditCheckService();
        AccountService account = new AccountService();
        LoanHistoryService history = new LoanHistoryService();
        LoanApprovalFacade loan = new LoanApprovalFacade(creditScore,account,history);
        Console.WriteLine(loan.IsEligible("Alice") + "\n" + "Result: Loan Approved");
        
    }
}