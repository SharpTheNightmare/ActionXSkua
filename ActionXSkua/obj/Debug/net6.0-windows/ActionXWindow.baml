   M S B A M L   `   `   `  ����C  ?Skua.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:Skua.WPF;assembly=Skua.WPFSkua.WPF  5      F BActionXSkua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ActionXSkuaActionXSkua 5	         ActionXSkua.ActionXWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      8wpf(clr-namespace:Skua.WPF;assembly=Skua.WPF     5      +localclr-namespace:ActionXSkua     5	      -   5        $
��Main��5        � Title$  ActionX Skua��5         CustomWindow#��[  5      $	��760��5      $	��350��5      $
��1000��5      $	��350��5      $	��517��5      $	��350��5       � 	Resources 5       �� Source�� 5   
   $- '/ActionXSkua;component/ResourceDir.xaml?�6   %    .��5      � .+�5   
   �� -   5         ��Name$ HostIPTextBox��5      $
��Left=�6)   $��	34,10,0,0q�6D    �� TextWrapping$
 Wrap=�6W   $��	127.0.0.1��6k   $	��Top=�6|   $	��115��6�    �� TextAlignment$ Center=�6�   �� 5   
   $��IP��6   $
��Left=�6   $��	16,11,0,0q�68   $	��Top=�6K   �� 5   
   -   5        $ PortTextBox��5      $
��Left=�6'   $��	34,40,0,0q�6B   $
 Wrap=�6U   $
��1024��6i   $	��Top=�6u   $	��115��6�   $ Center=�6�   6�   �� 5   
   $
��Port��6   $
��Left=�6   $��4,41,0,0q�6:   $	��Top=�6L   �� 5   
   -   5         ��Name$ ClientCheckBox��5      $��	Is Client��6+   $
��Left=�6?   $��
165,13,0,0q�6Z   $	��Top=�6n    d� 	IsChecked$ FalseY�6�   6�   �� 5   
   -   5         ��Name$ StartConButton��5      $��Start��6)   $
��Left=�69   $��
165,36,0,0q�6T   $	��Top=�6h   6�   �� 5    
   -   5        $ 
LogTextBox��5       $��Right=�6&   $��	0,10,10,0q�6B   $
 Wrap=�6U   $	��Top=�6i   $	��481��6�   $	��252��6�   $
��Left=�6�   "	 �� VerticalScrollBarVisibility$	 Visible=�6�   �� 5!   
   -   5        
 ��Name$
 ConClientTextBox��5!      $��Client Connected: 0��6*   $
��Left=�6H   $��267,311,0,0q�6c   $	��Top=�6x   $��23��6�   �� 5"   
   -   5        $ BroadcastTextBox��5"      $
��Left=�6,   $��269,277,0,0q�6G   $
 Wrap=�6\   $��Hello World!��6p   $	��Top=�6�   $	��417��6�   $��29��6�   �� 5#   
   -	   5        $ BroadcastMSG��5#      $
��Send��6'   $
��Left=�66   $��691,277,0,0q�6Q   $	��Top=�6f   $��29��6~   $��59��6�   $��12(�6�   6�   �� 5$   
   -
   5        $ LoadQuestCheckBox��5$      $��
Load Quest��6.   $
��Left=�6C   $��	42,84,0,0q�6^   $	��Top=�6q   $
 TrueY�6�   �� 5%   
   -   5        $ AcceptQuestCheckBox��5%      $��Accept Quest��60   $
��Left=�6G   $��
137,84,0,0q�6b   $	��Top=�6v   $
 TrueY�6�   �� 5&   
   -   5        $ CompleteQuestCheckBox��5&      $��Complete Quest��62   $
��Left=�6K   $��
15,110,0,0q�6f   $	��Top=�6z   $
 TrueY�6�   �� 5'   
   -   5        $ GetMapItemCheckBox��5'      $��Get Map Item��6/   $
��Left=�6F   $��137,110,0,0q�6a   $	��Top=�6v   $
 TrueY�6�   �� 5(   
   -   5        $ MapJoinCheckBox��5(      $��Join Map��6,   $
��Left=�6?   $��
15,136,0,0q�6Z   $	��Top=�6n   $
 TrueY�6�   �� 5)   
   -   5        $ CellJumpCheckBox��5)      $��	Jump Cell��6-   $
��Left=�6A   $��103,136,0,0q�6\   $	��Top=�6q   $
 TrueY�6�   �� 5*   
   -   5        $ BuyCheckBox��5*      $	��Buy��6(   $
��Left=�66   $��196,136,0,0q�6Q   $	��Top=�6f   $
 TrueY�6~   �� 5+   
   -   5        $ HostTooCheckBox��5+      $��Host too��6,   $
��Left=�6?   $��106,179,0,0q�6Z   $	��Top=�6o   �� 5,   
   -   5        $ HidePlayersCheckBox��5,      $��Hide Players��60   $
��Left=�6G   $��160,241,0,0q�6b   $	��Top=�6w   6�   �� 5-   
   -   5        $ ProvokeCheckBox��5-      $��Provoke��6,   $
��Left=�6>   $��
33,241,0,0q�6Y   $	��Top=�6m   6�   �� 5.   
   -   5        $ LagKillerCheckBox��5.      $��
Lag Killer��6.   $
��Left=�6C   $��
21,269,0,0q�6^   $	��Top=�6r   6�   �� 5/   
   -   5        $ SkipCutsceneCheckBox��5/      $��Skip Cutscene��61   $
��Left=�6I   $��152,269,0,0q�6d   $	��Top=�6y   6�   �� 50   
   -   5        $ AutoAttackCheckBox��50      $��Auto Attack��6/   $
��Left=�6E   $��
20,211,0,0q�6`   $	��Top=�6t   6�   �� 51   
   -   5        $ InfiniteRangeCheckBox��51      $��Infinite Range��62   $
��Left=�6K   $��165,211,0,0q�6f   $	��Top=�6{   6�   �� 52   
   -   5        $ UnlockButton��52      $��Unlock��6'   $
��Left=�68   $��210,179,0,0q�6S   $	��Top=�6h   $��12(�6�   $��23��6�   $��73��6�   6�   54      55      