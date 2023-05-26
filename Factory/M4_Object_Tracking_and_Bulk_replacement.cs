public class TrackingThemeFactory
{
  //Weak reference won't stop GC to collect the actual object
  private readonly List<WeakReference<ITheme>> themes = new ();
  
  public ITheme CreateTheme(bool dark)
  {
    //Imaging we have two theme classes
    ITheme theme = dark ? new DarkTheme() : new LightTheme();
    themes.Add(new WeakReference<ITheme>(theme));
    return theme;
  }
}

public class Ref<T> where T : class
{
  public T Value;
  
  public Ref(T value)
  {
    Value = value;
  }
}

public ReplaceableThemeFactory
{
  private readonly List<WeakReference<Ref<ITheme>>> themes = new();
  
  private ITheme createThemeImpl(bool dark)
  {
    return dark? new DarkTheme(); new LightTheme();
  }
  
  //The Ref here is important, all consumers rely on this to prevent some consumers to reassign the concrete ITheme.
  //But it is not forcing, so it cannot prevent people to break the rule
  public Ref<ITheme> CreateTheme(bool dark)
  {
    var r = new Ref<ITheme>(createThemeImpl(dark));
    themes.Add(new(r));
    return r;
  }
  
  public void Replacetheme(bool dark)
  {
    foreach(var wr in themes)
    {
      if(wr.TryGetTarget(out var reference))
      {
        reference.Value = createThemeImpl(dark);
      }
    }
  }
  
}


public static void Main()
{
  var factory = new TrackingThemeFactory();
  var theme1 = factory.CreateTheme(true);
  var theme2 = factory.CreateTheme(false);

  var factory2 = new ReplaceableThemeFactory();
  var magicTheme = factory2.CreateTheme(true);
  //now dark theme
  factory2.Replacetheme(false);
  //now light theme
  
}