/*
 * 自定义View中的Controller继承此类
 * 步骤： 1. 在Entity实体类中为要创建自定义的属性添加View属性。
 *           2. 创建相应的视图。
 *           3.在Scripts\Modules\custom目录下创建相应的TypeScript模块，模块名字规则为：类名+属性名  ，全部小写。如User类中的Permissions属性命名为：userpermissions
 *              模块实现一个控制器，自定义功能在其中定义。并继承此接口。
 *           4. 在视图中使用控制器名称为：模块名称+Ctrl
 */
interface ICoustom {
    $inject: string[];
    constructor;
} 