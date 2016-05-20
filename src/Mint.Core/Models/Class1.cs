
using System;

public class Rootobject
{
    public Account[] Account { get; set; }
    public Metadata metaData { get; set; }
}

public class Metadata
{
    public DateTime asOf { get; set; }
    public int totalSize { get; set; }
    public int pageSize { get; set; }
    public int currentPage { get; set; }
    public int offset { get; set; }
    public int limit { get; set; }
    public Link[] link { get; set; }
}

public class Link
{
    public Otherattributes otherAttributes { get; set; }
    public string href { get; set; }
    public string rel { get; set; }
}

public class Otherattributes
{
    public string method { get; set; }
}

public class Account
{
    public string type { get; set; }
    public string bankAccountType { get; set; }
    public float availableBalance { get; set; }
    public float interestRate { get; set; }
    public bool userFreeBillPay { get; set; }
    public bool userAtmFeeReimbursement { get; set; }
    public float numOfTransactions { get; set; }
    public Metadata1 metaData { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public float value { get; set; }
    public bool isVisible { get; set; }
    public bool isDeleted { get; set; }
    public bool planningTrendsVisible { get; set; }
    public string accountStatus { get; set; }
    public string systemStatus { get; set; }
    public string currency { get; set; }
    public string fiLoginId { get; set; }
    public string fiLoginStatus { get; set; }
    public float currentBalance { get; set; }
    public string cpId { get; set; }
    public string cpAccountName { get; set; }
    public string cpAccountNumberLast4 { get; set; }
    public bool hostAccount { get; set; }
    public string fiName { get; set; }
    public int accountTypeInt { get; set; }
    public bool isAccountClosedByMint { get; set; }
    public bool isAccountNotFound { get; set; }
    public bool isActive { get; set; }
    public bool isClosed { get; set; }
    public bool isError { get; set; }
    public bool isHiddenFromPlanningTrends { get; set; }
    public bool isTerminal { get; set; }
    public string userCardType { get; set; }
    public string creditAccountType { get; set; }
    public float creditLimit { get; set; }
    public float availableCredit { get; set; }
    public float minPayment { get; set; }
    public float absoluteMinPayment { get; set; }
    public float statementMinPayment { get; set; }
    public DateTime statementDueDate { get; set; }
    public float statementDueAmount { get; set; }
}

public class Metadata1
{
    public DateTime createdDate { get; set; }
    public DateTime lastUpdatedDate { get; set; }
    public Link1[] link { get; set; }
}

public class Link1
{
    public Otherattributes1 otherAttributes { get; set; }
    public string href { get; set; }
    public string rel { get; set; }
}

public class Otherattributes1
{
}
