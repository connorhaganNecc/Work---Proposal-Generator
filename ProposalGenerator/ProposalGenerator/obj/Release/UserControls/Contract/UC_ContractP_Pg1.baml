   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  ProposalGenerator%   ProposalGenerator.ContractP_Pg1   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     6sys&clr-namespace:System;assembly=mscorlib     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     .���   � ColumnDefinitions  �� $	��100 ��� $��* ��� $	��100 � � RowDefinitions �� $��75 ��� $��* ��� $	��100 �.+�� $��1��$��1�� �� $��40 ��� $��30 ��� $��* ��� $��30 ��� $��* �.+��� 
�������
�������$��2q� �� CornerRadius$ 8,8,3,3��$��2��._��  �� $��50 ��� $��40 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 �  �� $	��150 ��� $��* ��� $	��150 ��� $��* � � 	Resources  �� 
TargetType �� Property �� Value��%3   '��       �� " ��.���  � ��$ 0,0,15,8q�.+��� $��0��$��4��$��Center=�$
��Bold"�$��16(�Enter Client Info�� $��Title��$��14(�$
��Left=�$��1��$��0���� -   $��TitleBox��$��1��$��1��$��30��$��14(�$
��Left=�.@���  �� 
IsSelected . .��None�� .��Mr.�� .��Ms.�� .��Mrs.�� $��Name:��$��14(�$
��Left=�$��2��$��0�� �� Target �� 	 �� ElementName$	 prepName���� -   $��FNAME��$��2��$��1��$��3���� $��
Last Name:��$��14(�$��Right=�$��2��$��2��$y�Hidden=� �� $	 prepName���� -   $��LNAME��$��2��$��3��$y�Hidden=��� $��_Name(optional):��$��14(�$
��Left=�$��3��$��0�� �� $	 prepName���� -   $��CO��$��3��$��1��$��3���� $��	_Address:��$��14(�$
��Left=�$��4��$��0�� �� $	 prepAddress���� -   $��prepAddress��$��4��$��1��$��3���� $��_Town:��$��14(�$
��Left=�$��5��$��0�� �� $	 prepTown���� -   $��prepTown��$��5��$��1��$��1���� $��_State:��$��14(�$��Right=�$��5��$��2�� �� $	 	prepState���� -   $��	prepState��$��5��$��3��$��1���� $��_Zip:��$��14(�$
��Left=�$��6��$��0�� �� $	 prepZip���� -   $��prepZip��$��6��$��1��$��1���� 
�������
�������$��2q�$ 8,8,3,3��$��4��._��� .���  �� $��50 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��* �  �� $	��150 ��� $��* ��� $	��100 ��� $��* � ��%3   '��       �� " ��.���  � ��$ 0,0,15,8q�.+��� $��0��$��4��$��Center=�$
��Bold"�$��16(�Enter Property Location�� $��_Same as Client��$��14(�$
��Left=�$��1��$��0�� �� $	 sameClientCheck���� -	   $��sameClientCheck��$��1��$��1���� -
   $��propAddressLabel��$��	_Address:��$��14(�$
��Left=�$��2��$��0�� �� $	 propAddress���� -   $��propAddress��$��2��$��1��$��3���� -   $��propTownLabel��$��_Town:��$��14(�$
��Left=�$��3��$��0�� �� $	 propTown���� -   $��propTown��$��3��$��1��$��3���� -   $��propZipLabel��$��_Zip:��$��14(�$
��Left=�$��4��$��0�� �� $	 propZip���� -   $��propZip��$��4��$��1��$��3���� -   $��propAssMapLabel��$��_Assessor's map:��$��14(�$
��Left=�$��5��$��0�� �� $	 propZip���� -   $��
propAssMap��$��5��$��1��$��3���� -   $��propAssBlockLabel��$��_Assessor's block:��$��14(�$
��Left=�$��6��$��0�� �� $	 propZip���� -   $��propAssBlock��$��6��$��1��$��3���� -   $��propAssBlockLot��$��_Assessor's lot:��$��14(�$
��Left=�$��7��$��0�� �� $	 propZip���� -   $��
propAssLot��$��7��$��1��$��3��� $��2�� �� $��* ��� $��* ��� $��* �]� $��0��$��0��$��3��.+��� -   $��50��$��10q�$��10q�$��12(�$��Center=�$	��Top=�$	��top=�$��Right=�.��Return to Main Menu� $��0��$��2��$��3��  �� $	��200 ��� $��* ��� $	��100 ��� $	��150 �.+��� -   $��50��$��10q�$��10q�$��12(�$��Center=�$
��Left=�$	��top=�$��Right=�$��3��.��	Next Page�� -   $��50��$��10q�$��10q�$��12(�$��Center=�$
��Left=�$	��top=�$��Right=�$��0��.��Cancel