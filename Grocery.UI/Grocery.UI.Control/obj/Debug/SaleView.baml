   M S B A M L   `   `   `  ����M  IGrocery.UI.Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Grocery.UI.ControlGrocery.UI.Control  5      !    Grocery.UI.Control.SaleView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Grocery.UI.Control     5        � 	Resources  5
         	BackImage��%G   &	        �� 5   
   $)��#C:\Users\Vlad\Desktop\img_70486.png��6"   5      .��5      � $��Stretch=�6   $��Stretch=�6'    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $	��600 �6   .+�5   
   � $��0��6   $��2��6   .+�5      �� -   5         ��Name$ 	MainPanel��5      $��0,0,0,0q�5      $
��auto��6*   $��70��5      
�����_� �� Orientation$ 
Horizontal=�5      .+�5       �� -   5         ��Name$ BackBtn��5       $��50��5!      $��50��5"      $��10 0 0 0q�5#      |�.  #��[" �5%      #��[  5'      ��5&      �� *GetBackCommand+5'      5(      5)      �� 5+   
   $
��Left=�6   $��Center=�60   $��0 30 0 0q�6K   $��1��6]   $��1��6m   $ Vertical=�6z   .+�5-      � $	��500��6   $��0 0 0 0q�6   $��0��60   $��2��6@   .+�5.      �� -   5         ��Name$ 
lblProduct��5.      $��0 0 0 0q�6,   
���   �$��Product:��6P   5/      �� 51      -   5         ��Name$ listProduct��51      $��25��60   $	��100��6<   $��-230 0 0 10q�6H   �� 53      -   5        $ errorProduct��53      $��
200 0 0 10q�6.   
���P��$�� ��6U   $��Center=�6`   $
��Left=�6{   54      55      � 57      $	��500��6   $��0 0 0 0q�6   $��0��60   $��2��6@   .+�58      �� -   5        $ lblCount��58      $��0 0 0 0q�6*   
���   �$��Count:��6N   59      �� 5;      -   5         ��Name$ countTxt��5;      $��85 10 270 10q�6,   ��6C   �� 	 �� Path$	 SetPrice�.��6b   5<      �� 5>      -   5        $ 
errorCount��5>      $��
230 0 0 10q�6,   
���P��$�� ��6S   $��Center=�6^   $
��Left=�6y   5?      5@      � 5B      $	��500��6   $��0 0 0 0q�6   $��0��60   $��2��6@   .+�5C      �� -	   5        $ lblDatetime��5C      $��0 0 0 0q�6-   
���   �$��	Datetime:��6Q   5D      (  "System.Windows.Controls.DatePicker  5F      -
   5        
  Name$
 datetimePick��5F      $��85 0 270 10q�63   �� 5H      -   5        $ errorDatetime��5H      $��
230 0 0 10q�6/   
���P��$�� ��6V   $��Center=�6a   $
��Left=�6|   5I      5J      � 5L      $	��500��6   $��0 0 0 0q�6   $��0��60   $��2��6@   .+�5M      �� -   5        $ lblPrice��5M      $��0 0 0 0q�6*   
���   �$��Price:��6N   5N      �� 5P      -   5        $ priceTxt��5P      $��85 10 270 10q�6,   {�.  .��6T   5Q      5R      � 5T      $	��500��6   $��0 0 0 0q�6   $��0��60   $��2��6@   .+�5U      �� -   5        $ 	lblSeller��5U      $��0 0 0 10q�6+   
���   �$��Seller:��6P   5V      �� 5X      -   5        $ 	sellerTxt��5X      $��85 10 270 10q�6-   {�.  .��6U   5Y      5Z      �� 5\      -   5        $ 
ExecuteBtn��5\      $��100 20 270 0q�5]      |�.  $��Confirm��5_      ��5`      �� *ExecuteCommand+5a      5c      5d      