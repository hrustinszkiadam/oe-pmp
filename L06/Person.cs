namespace L06;

class Person(int seqn, string survey, int gender, int age, double bmi, double glucose)
{
    private int seqn = seqn;
    private string survey = survey;
    private int gender = gender;
    private int age = age;
    private double bmi = bmi;
    private double glucose = glucose;

    public int GetSeqn()
    {
        return seqn;
    }

    public string GetSurvey()
    {
        return survey;
    }

    public int GetGender()
    {
        return gender;
    }

    public int GetAge()
    {
        return age;
    }

    public double GetBmi()
    {
        return bmi;
    }

    public double GetGlucose()
    {
        return glucose;
    }
}
