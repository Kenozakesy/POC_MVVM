   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   J FTreeViewExample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:TreeViewExample.Business.UI_Models"TreeViewExample.Business.UI_Models 5   	   Q-clr-namespace:TreeViewExample.Business.ModelsTreeViewExample.Business.Models 5   	   m;clr-namespace:TreeViewExample.Business.Models.DiagramModels-TreeViewExample.Business.Models.DiagramModels 5	   	   Y1clr-namespace:TreeViewExample.Business.Interfaces#TreeViewExample.Business.Interfaces 5
   	   9   3TreeViewExample.UI.Views.AddParameterToObjectWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   Blocal0clr-namespace:TreeViewExample.Business.UI_Models     5   	   >this-clr-namespace:TreeViewExample.Business.Models     5   	   Kdia;clr-namespace:TreeViewExample.Business.Models.DiagramModels     5	   	   Bthat1clr-namespace:TreeViewExample.Business.Interfaces     5
   	   $	��400��5   +   $	��800��6;   $
��1000��6J     � WindowState$  	Maximized=�6W    � Title 6	   ��  �� Path$ 
ViewHeader� � 	Resources 5         BorderStyle �� 
TargetType �� Property �� Value  TextboxStyle  ButtonAddStyle �� Triggers �� Binding	 �� Value  GridViewColumnHeader  ComboBoxStyle  ListItemStyle
 �� RelativeSource �� AncestorType
 � Tag m� Command m� CommandParameter  ComboboxTemplate �� DataType:  4TreeViewExample.Business.Interfaces.IParameterObject �� SelectedValue  NumericTemplate  TextTemplateG  ATreeViewExample.Business.Models.DiagramModels.ParameterDefinition��%�  &	        &	 �     &	     &	     &	 �    &	 �    &	 �    &	 L    &	 �    (��     5M      *, +)�� 5   
   " ��6$   .�5      ��  � ��
 �   �6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 2q�6'   5      �� 5   
   " ��6%   .�5      ��  � ��$ 20��6*   �� 5       � ��$ 0 5 0 0q�6'   5      �� 5   
   " ��6'   .�5      ��  � ��$ 20��6*   �� 5       � ��$ 0 5 0 0q�6'   �� 5       � {� . 6*    5      �� 5       6   �� $ SelectedStandardParameter�	 6Q   Z� .a�5      ��  � {� .  62   5      5!      �� 5"   
   " ��6-   .�5#      ��  � ��$ Center=�6;   6L   �� 5$       � ��$
 Bold"�6+   6:   �� 5%       � ��$ 30��6'   64   �� 5&       � ��$ 	20 0 20 0q�6(   6<   5'      �� 5(   
   " ��6&   .�5)      ��  � {� . 69    5*      �� 5+       6   �� $' !AvailableStandardParameters.Count�	 06Y   .a�5,      ��  � {� .  62   5-      5/      �� 50   
   " ��6&   .�51      ��  � ��
 �����6,   �� 52       � ��$ 0 0 0 1q�60   �� 53       � ��$
 Left=�6;   �� 55       �@�Tag 6$   �� 
 �� $ WindowL�6l   �� 56       �@�ContextMenu 57      �� 58       6"   �� *PlacementTarget.Tag+
 �� *Self+.@�59      m� $��Remove��6#    63   �� *20Tag.DataContext.RemoveParameterFromObjectCommand+
 �� $ ContextMenuL� 6�   �� 5:      5<      5=      �� 5?   
   "  60   .R�5@      �� $	��100��6�   ��6   �� $- 'ParameterDefinition.ValidValuesCombobox� 6\   �� $ Value�6�   5A      �� 5C   
   "  6/   .R�5D      � .+�5E      �� ��6   �� $ Value�5F      5G      �� 5I   
   "  6,   .R�5J      �� $��50��62   ��6   �� $ Value�62   5K      �� 5M   
   "  6   .R�5N      �� ��6   �� $ 	paf_ParNm�6:   5O      5Q      .��5R      �  � RowDefinitions 5S   
   �� 5T      $��* �6   6)    � ColumnDefinitions 5V   
   �� 5W      $��* �6   6,   �� 5X      $��3 �6   6,   �� 5Y      $
��0.2* �6   6.   .+�5\   
   �� #��[  6   ._�5]      �� #��[ 6   $��Stretch=�6K   ��6p   �� $ ParameterList� �� View 5^      �� 5_      .P�5a      �� $��ParName��6)    �� Width$
 Auto��6:    �� HeaderContainerStyle# [ 6G    �� DisplayMemberBinding 6�   �� $# ParameterDefinition.paf_ParNm��� 5b      $��Description��6)   $
 auto��6>   # [ 6K    6�   �� $% ParameterDefinition.paf_ParDesc��� 5c      $��ValueUOM��6)   $
 auto��6;   # [ 6H    6�   �� $) #ParameterDefinition.paf_ParValueUOM��� 5e      $��Value��6)   $
 auto��68   # [ 6E    �� CellTemplate 5f      �� 5h   "   "  6/   .R�5i   &   �� ��65   �� ��5j   *   �� 5k   .   " ��64   .�5n   2   ��  � ��# [ 6T    5q   2   �� 5r   6    6B   �� $3 -ParameterDefinition.ValidValuesCombobox.Count� �� 	Converter 4  .TreeViewExample.Business.UI_Models.GreaterThan  *0+	 true6�   .a�5s   :   ��  � ��# [ 6\   5t   7   �� 5v   6    6C   �� $+ %ParameterDefinition.Validvalues.Item2�   *0+	 true6�   .a�5w   :   ��  � ��# [ 6\   5x   7   5{   /   5}   '   5~   #   5�      �� 5�      $��Valid Values��6)   $
 auto��6?   # [ 6L    6�   �� $) #ParameterDefinition.paf_ValidValues��� 5�      $��Is standard parameter��6)   $
 auto��6H   # [ 6U    6�   �� $+ %ParameterDefinition.paf_IsStandardPar�5�      5�      5�      �� 5�   
   $��1��6   $��Stretch=�6'   $��3��6E   
���   �$��0.5 0q�6c   6~   �� 5�   
   $��2��6   #��[  6!   ._�5�      �  5�      �� 5�      $��* �6$   61   �� 5�      $��* �6$   61    5�      �� 5�      $��* �6'   63   .+�5�      �� $��0��6   $��8q�6*    �� Orientation$ Vertical=�65   .+�5�      �� .��6   
Parameters6(   �� 5�      #��[ 6   ��6F   �� $! AvailableStandardParameters� �� SelectedItem 6   �� $ SelectedStandardParameter�6�   �� 5�      #��[ 6   $��0 5 0 20q�6E   ��6W   �� $! AddParameterToObjectCommand�.��6�   Add6�   �� 5�      .��6   Customer Parameters61   �� 5�      6!   �� 5�      #��[ 6   .��6D   Add6I   �� 5�      #��[ 6   $��0 5 0 20q�6C   ��6U   �� *" OpenCreateParameterWindowCommand+.��6�   Create parameter6�   �� 5�      .��6   Add required Parameters65   �� 5�      #��[ 6   ��6C   �� *AddRequiredParametersCommand+.��6t   Add6y   5�      �� 5�      $��1��6   $��8q�6*   $��Bottom=�65   .+�5�      �� #��[ 6   ��6C   �� *FinishEditingCommand+.��6l   Finish6t   5�      5�      5�      5�      5�      