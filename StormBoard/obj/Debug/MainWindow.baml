   M S B A M L   `   `   `  ����E  AStormBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:StormBoard
StormBoard  5   	       StormBoard.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )thisclr-namespace:StormBoard     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��600��6)    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $" Resources/NoteTemplates.xaml?�6%   �� 5
      $" Resources/MainTemplates.xaml?�6%   %    5      .��5      � ���#cccccc � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��
Stormboard��6   $��5q�6*   $��26(�65   $
��Bold"�6C   ���#3333336U   5      �� 5   
   
���   �$��2q�6%   $��1��69   
�������._�5      �� -   5        $��
tabControl��5      .@�5      �� $��Test 123��6   .��5      �� -   5         ��Name$ workArea��5      .+�5         StormBoard.Note     NoteText$ Hello World!��6$      NoteTemplate#��[  6<   
 �� Top$ 50��6e   	 �� Left$	 50��6u   5      5      �� 5       -   5        $��newTab��5       $��+��6(   5!      5"      �� 5$   
   -   5        $	��Add��5$      $��Right=�64   $
��10 5q�6P   $��2��6^     SeamlessBorderedButton#��[ 6k   5%      5&      