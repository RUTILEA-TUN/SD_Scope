   M S B A M L   `   `   `  ????C  ?SD_Scope, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SD_Scope.ViewsSD_Scope.Views  5      #    SD_Scope.Views.InspectionView   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SD_Scope.Views     5      h dSyncfusion.SfProgressBar.WPF, Version=20.1500.0.55, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.WPF, Version=20.1500.0.55, Culture=neutral, PublicKeyToken=3d67ed1f87d44c894
Syncfusion!http://schemas.syncfusion.com/wpf   5        ? 	Resources  5
         masterTipImage ?? 	UriSource  croppedTipImage ?? Source ?? 
SourceRect  masterEntireImage  croppedEntireImage??%?   &	        &	 )     7   &	 W     &	 ?     7  ?? 5   
   $ /Images/tip.bmp??6-   ?? 5   
   8   $ 480 324 500 500??6Y   ?? 5   
   $ /Images/entire.bmp??60   ?? 5   
   8   $ 0 700 2592 600??6_   5      .??5      ? ???#E0E0E0.+?5   
   ]? $
??True??6   .+?5      ? $	??Top=?6   $??50??6(    ? ColumnDefinitions 5      ?? 5      $??* ?6'   ?? 5      $??* ?6'   ?? 5      $??* ?6'   .+?5      ?? $??Finish Inspection??6   $??
10,15,5,15q?65   ???	#FFAFD1F8  5       ?? 
TargetType ?? Property ?? Value??%^   '??       ?? 5      " ??6    .?5      ??  ?@??CornerRadius$ 5??6=   5      5      5'      ?? 5(      $??1??6   .+?5)      ?? $??
Inspection??6   $??Center=?61   ?? 5*      $??10:56   25.6°C  36.9%??6   $??Center=?6<   5+      ? 5-      $??2??6    5.      ?? 5/      $??* ?6+   ?? 50      $??* ?6+   .+?52      ?? -   5        $??bFilterSettings??52   V   $??Filter Settings??6   $??10q?67   
???????  53      ??%^   '??       ?? 54      " ??6$   .?55   "   ??  ?@??CornerRadius$ 5??6A   56      57      58      ?? 59      -   5        $??bCameraSettings??59   f   $??1??6   $??Camera Settings??6-   $??10q?6G   
???????  5:      ??%^   '??       ?? 5;      " ??6$   .?5<   "   ??  ?@??CornerRadius$ 5??6A   5=      5>      5?      5B      5D      ? 5E      $??Bottom=?6   $	??100??6.    5F      ?? 5G      $??* ?6'   ?? 5H      $
??Auto ?6'   ?? 5I      $??* ?6'   .+?5K      ? $??1??6    ? RowDefinitions 5L      ?? 5M      $??* ?6(   ?? 5N      $
??Auto ?6(    5P      ?? 5Q      $??* ?6+   ?? 5R      $??* ?6+   ?? 5S      $??* ?6+   ?? 5T      $??* ?6+   ?? 5U      $??* ?6+   ?? 5V      $??* ?6+   ?? 5W      $??* ?6+   ?? 5X      $??* ?6+   ?? 5Y      $??* ?6+   .+?5[      ?? $??0??6   $??0??6-   $??Cancel??6:   $??8(?6K   $??30??6X   $??30??6c   $??	12,1,12,8q?6o   6?   ?? 5]      $??OK??6   $??50??6*   $??50??65   $??2,1,2,10q?6A   $??1??6S   $??0??6`   ???#0064006?   ?? 5^      $??AB??6   $??50??6*   $??50??65   $??2,1,2,10q?6A   $??1??6S   $??1??6`   ???#FF45006?   ?? 5_      $	??AB2??6   $??50??6+   $??50??66   $??2,1,2,10q?6B   $??1??6T   $??2??6a   ???#FF45006?   ?? 5`      $??CD??6   $??50??6*   $??50??65   $??2,1,2,10q?6A   $??1??6S   $??3??6`   ???#0000CD6?   ?? 5a      $	??CD2??6   $??50??6+   $??50??66   $??2,1,2,10q?6B   $??1??6T   $??4??6a   ???#0000CD6?   ?? 5b      $??E??6   $??50??6)   $??50??64   $??2,1,2,10q?6@   $??1??6R   $??5??6_   ???#FFA5006?   ?? 5c      $??E2??6   $??50??6*   $??50??65   $??2,1,2,10q?6A   $??1??6S   $??6??6`   ???#FFA5006?   ?? 5d      $
??Test??6   $??50??6,   $??50??67   $??2,1,2,10q?6C   $??1??6U   $??7??6b   ???#FEBF4C6?   ?? 5e      $??Dunno??6   $??50??6-   $??50??68   $??2,1,2,10q?6D   $??1??6V   $??8??6c   ???#8000806?   ?? 5f      	 ?? CornerRadius$	 10??6   $??13??6/   $??13??6:   
 ?? Padding$
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   ._?5g      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   16?   5h      ?? 5i      $	 10??6   $??13??6/   $??13??6:   $
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   $??1??6?   ._?5j      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   ?? 6   $?1??6?   6?   5k      ?? 5l      $	 10??6   $??13??6/   $??13??6:   $
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   $??2??6?   ._?5m      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   ?? 6   $?1??6?   6?   5n      ?? 5o      $	 10??6   $??13??6/   $??13??6:   $
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   $??3??6?   ._?5p      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   ?? 6   $?1??6?   6?   5q      ?? 5r      $	 10??6   $??13??6/   $??13??6:   $
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   $??4??6?   ._?5s      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   ?? 6   $?1??6?   6?   5t      ?? 5u      $	 10??6   $??13??6/   $??13??6:   $
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   $??5??6?   ._?5v      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   ?? 6   $?1??6?   6?   5w      ?? 5x      $	 10??6   $??13??6/   $??13??6:   $
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   $??6??6?   ._?5y      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   ?? 6   $?1??6?   6?   5z      ?? 5{      $	 10??6   $??13??6/   $??13??6:   $
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   $??7??6?   ._?5|      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   ?? 6   $?1??6?   6?   5}      ?? 5~      $	 10??6   $??13??6/   $??13??6:   $
 0,0,0,0q?6F   
???????
???   ?$??1q?6   $??
38,34,3,53q?6?   $??2??6?   $??8??6?   ._?5      ?? $??Center=?6$   $??10(?6A   $??Medium"?6O   $??Center=?6c   ?? 6   $?1??6?   6?   5?      5?      :  4Syncfusion.UI.Xaml.ProgressBar.SfCircularProgressBar  5?      -   5          Name$# CustomContentProgressBarLevel??5?   C   $??2??63   4  .Syncfusion.UI.Xaml.ProgressBar.ProgressBarBase   Progress$ 20Q?6j   $	??100??6x   $??Right=?6?   $??Bottom=?6?      ProgressContent 5?      ?? 5?      .+?5?      ??  ?? TextAlignment$ Center=?6V   ??6(   ?? *
Progress+ ?? StringFormat$	 {0}?? ? DataContext 6m   %  System.Windows.Markup.Reference  *CustomContentProgressBarLevel+?? 5?      
???   ?
???   ?6<   ?? 5?      $	??100??6(   5?      5?      5?      ?? 5?      $
??Left=?6   $	 6??6+   ???#E0E0E0???#E0E0E0$??3q?6g   $??10q?6{    J? Effect 5?      3  -System.Windows.Media.Effects.DropShadowEffect  5?         ShadowDepth$ 0Q?6'      
BlurRadius$ 10Q?67   ._?5?      ?? $	??120??6   .+?5?      ?? $	 3??6   
???   ?
???   ?$??7q?6U   $??2q?6i   ._?5?      ?? $
??Auto??6    $
??Auto??6-   ??5?      U? 5?   "    U? Source# [ 64    U? 	Transform 5?   &   ?? 5?   *    ?? Angle$	 180Q?6:   5?   #   5?      5?      ?? 5?      $	 3??6   
???   ?
???   ?$??7q?6U   $??2q?6i   ._?5?      ?? $
??Auto??6    $
??Auto??6-   ??5?      U? 5?   "   # [ 64    5?   &   ?? 5?   *   $	 180Q?6:   5?   #   5?      5?      5?      5?      ?? 5?      $??Right=?6   $	 6??6,   ???#E0E0E0???#E0E0E0$??3q?6h   $??10q?6|    5?        5?      $ 0Q?6'   $ 10Q?67   ._?5?      ?? $	??120??6   .+?5?      ?? .??6   Error Handling6-   5?      5?      ?? 5?      $	 6??6   ???#E0E0E0???#E0E0E0$??3q?6Q   $??10q?6e    5?        5?      $ 0Q?6'   $ 10Q?67   ._?5?      ]? .+?5?      ?? $	??Top=?6   $	 3??62   
???   ?
???   ?$??7q?6j   $??2q?6~   ._?5?      ?? -   5         ??Name$ iCamera??5?   f   $	??600??6    $	??240??6,   #??[ 69   6f   5?      ?? 5?      $??Bottom=?6   $	 3??65   
???   ?
???   ?$??7q?6m   $??2q?6?   ._?5?      ?? -   5        $ 	iFiltered??5?   f   $	??600??6    $	??240??6,   #??[ 69   6f   5?      5?      5?      5?      5?      5?      