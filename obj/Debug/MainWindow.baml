   M S B A M L   `   `   `  ����Q  MPhilAccessSQLInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PhilAccessSQLInterfacePhilAccessSQLInterface  5   	   '    !PhilAccessSQLInterface.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:PhilAccessSQLInterface     5   	   -   5          �Name$  winMain��5   	    � Title$ 
MainWindow��5   	   $	��477��6   $	��790��6)    � 
ResizeMode$ NoResize=�65   .��5	      ]� .+�5
   
   �� -   5        $��	statusBar��5
   ,   $��Bottom=�6   .@�5      �� .��5      �� -   5        $��
statusText��5      $��Ready��6.   5      �� 5      .��5      � -   5         �Name$ progressBar��5       � IsIndeterminate . $	��300��6J   $y�	Collapsed=�6V   5      5      � 5   
   .+�5      �� -   5         ��Name$ lblPath��5      $��No path set��6%   $��Center=�6;   $��52��6X   $��0,10,0,0q�6d   $	��Top=�6v   $	��726��6�   �� 5      -   5         ��Name$ 	btnOpenDB��5      $��Open Access DB��6(   $
��Left=�6A   $��38��6\   $��	10,78,0,0q�6h   $	��Top=�6{   $	��134��6�   6�   �� 5      -   5         ��Name$ txtSQLQuery��5      $
��Left=�6+   $	��209��6F    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��681��6   $��
82,132,0,0q�6�   �� 5      $��
Enter SQL:��6   $
��Left=�6)   $��40��6D   $��10,0,0,0q�6P   $��Center=�6b   $��67��6}   �� 5      -   5        $ 	btnRunSQL��5      $��Run SQL��6(   $
��Left=�6:   $��60��6U   $��591,353,0,0q�6a   $	��Top=�6v   $	��172��6�   {�.  6�   �� 5      -	   5        $ btnReset��5      $��Reset��6'   $
��Left=�67   $��38��6R   $��
632,78,0,0q�6^   $	��Top=�6r   $	��131��6�   6�   �� 5      -
   5        $ 	lblDBInfo��5      $�� ��6'   $
��Left=�62   $��71��6M   $��
10,353,0,0q�6Y   $	��Top=�6m   $	��576��6�   5      5      5      